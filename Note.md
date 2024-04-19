#Identity MVC: Cấu hình Identity.
**Bước 1: Cài packages sau: 
	* Microsoft.AspNet.Identity.EntityFrameWork Bao gồm cả Microsoft.AspNet.Identity.Core.
	* Microsoft.AspNet.Identity.Owin.
	* Microsoft.Owin.Host.SystemWeb.
**Bước 2: Thêm 1 item OWIN Startup class:
	* Import các thư viện cần thiết để cấu hình
		* using Microsoft.AspNet.Identity;
		* using Microsoft.Owin.Security.Cookies;
		* using Microsoft.AspNet.Identity.EntityFramework;
	* Sau đó cấu hình
		public class Startup
		{
			public void Configuration(IAppBuilder app)
			{
				app.UseCookieAuthentication(new CookieAuthenticationOptions()
				{
					AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
					LoginPath = new PathString("/Account/Login")
				});
			}
		}
**Bước 3: Tạo một folder tên Identity:
	* Tạo một class trong folder Identity có tên là AppUser.
	* Import các thư viện cần thiết để cấu hình
		* using Microsoft.AspNet.Identity.EntityFramework;
	* Sau đó kế thừa lại lớp IdentityUser.
	* Có thể tạo thêm các thuộc tính như sau:
	public class AppUser : IdentityUser
    {
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
	
	* Tạo một class trong folder Identity có tên là AppDbContext.
	* Import các thư viện cần thiết để cấu hình
		* using Microsoft.AspNet.Identity.EntityFramework;
	public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() : base("MyConnectionString") { }
    }
	* Sau đó ta: enable-migrations -ContextTypeName EF_CodeFirst.Identity.AppDbContext -MigrationsDirectory IdentityMigration
	* Tạo: add-migration -Configuration EF_CodeFirst.IdentityMigration.Configuration init
	* Cập nhật lại: update-database -Configuration EF_CodeFirst.IdentityMigration.Configuration
	
	* Tạo một class trong folder Identity có tên là AppUserStore.
	* Import các thư viện cần thiết để cấu hình
		* using Microsoft.AspNet.Identity.EntityFramework;
	public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(AppDbContext appDbContext) : base(appDbContext) { }
    }
	
	* Tạo một class trong folder Identity có tên là UserManager.
	* Import các thư viện cần thiết để cấu hình
		* using Microsoft.AspNet.Identity.EntityFramework;
	public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store) { }
    }
	
**Bước 4: Cấu hình roles
	* VD: Ta cần 3 roles: Admin, manager, customer.
	* Tạo 1 method CreateRolesAndUsers trong class AppStart và gọi nó ngay trong method Configuration(IAppBuilder app){}
	public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDbContext()));
            var appDbContext = new AppDbContext();
            var appUserStore = new AppUserStore(appDbContext);
            var userManager = new AppUserManager(appUserStore);

            //Create role Admin.
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if(userManager.FindByName("admin") == null)
            {
                var user = new AppUser();
                user.UserName = "admin";
                user.Email = "admin@gmail.com";
                string userPwd = "admin123";

                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            //Create role Manager.
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            if(userManager.FindByName("manager") == null)
            {
                var user = new AppUser();
                user.UserName = "manager";
                user.Email = "manager@gmail.com";
                string userPwd = "manager123";

                var chkUser = userManager.Create(user, userPwd);
                if (chkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            //Create role Customer.
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
		
		

#Create login form with ViewModels(Show data by a model)

**Step 1: Create ViewModels folder
	* Create class RegisterVM
	using System.ComponentModel.DataAnnotations;
	
	*
	public class RegisterVM
    {
        [Required(ErrorMessage = "Username cannot be blank.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password cannot be blank.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword cannot be blank.")]
        [Compare("Password", ErrorMessage = "Password and Comfirm password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email cannot be blank.")]
        [EmailAddress(ErrorMessage = "Invalid email.")]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
	