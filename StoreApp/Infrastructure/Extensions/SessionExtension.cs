using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions
{
    //* static classın tüm öğeleri statik olur , newleme yapmadan ilgili sınıf adı üzerinden sınıf üyelerine erişebiliriz
    public static class SessionExtension
    {


        //* 
        public static void SetJson(this ISession session, string key, object value)
        {

            //Serialize edip hafızada saklayalım
            session.SetString(key, JsonSerializer.Serialize(value));
        }



        //generic 
        public static void SetJson<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }


        //extension method yazıyorsak neyi extends ediceğimizi ilk parametrede vermeliyiz
        public static T? GetJson<T>(this ISession session, string key)
        {

            var data = session.GetString(key);

            return data is null
            ? default(T)
            : JsonSerializer.Deserialize<T>(data);

        }
    }
}