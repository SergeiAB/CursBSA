using BookStoreWeb.DataContext;
using BookStoreWeb.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWeb.Service
{
    public class AccountServiice
    {
        private ContextBook db;

        public AccountServiice(ContextBook contextBook)
        {
            db = contextBook;
        }
      
        public User IsUser(string email, string password)
        {
            var user = db.Users.Include(x => x.Role).FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }

        public async Task<User> AddUser(RegisterModel model)
        {
            if (model.RoleName == null) model.RoleName = "user";
            Role userRole = await db.Roles.FirstOrDefaultAsync(x => x.RoleName == model.RoleName); ;

            User user =new User { Email = model.Email, Password = model.Password, 
                                  UserName = model.UserName, Phone = model.Phone };
            
            if (userRole != null)
                user.Role = userRole;
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public IEnumerable<Role> CreatEmploee()
        {
            var emploee = db.Roles.Where(x => x.RoleName == "admin" || x.RoleName=="trader" ).Include(y=> y.Users).ToList();
            return emploee;
        }
    }
}
