using System.Text.Json.Serialization;
using Entities.Models;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Models
{
    public class SessionCart : Cart
    {
        //adından da anlaşılcağı üzere sessiona bağlı olarak çalışacak bir ifade.
        //session üzerinde işlem yapıcaksak ISession interface yapısını burda kullanmamız gerekli


        //yapmak zorundayız çünkü oturum üzerinde çalışmalar yapıcağız

        [JsonIgnore] //Deserialize aşamasında görmezden gel
        public ISession? Session { get; set; }

        //cart bilgisiin getiricek bir method yaz 
        //httpcontextaccessor yardımıyla session'u okuyabilicecğiz o yüzden parametreyi gir =>

        //ihtiyaç duyduğumuz bir servisi alıcağız

        public static Cart GetCart(IServiceProvider services)
        {
            //sessiona erişim
            ISession session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;

            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();


            cart.Session = session;

            return cart;
        }


        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }


        public override void Clear()
        {
            base.Clear();

            Session?.Remove("cart");
        }


        public override void RemoveLine(Product product)
        {
            base.RemoveLine(product);

            Session?.SetJson<SessionCart>("cart", this);
        }
    }
}