using System.Collections.Generic;

namespace WPFTest
{
    public class ViewModelZob
    {
        public string Bqlskdf = "jambon";

        public ViewModelZob(List<Zob> zobs)
        {
            zobs.Add(new Zob()
            {
                Name = "Patrice",
                Color = "noir"
            });
        }

    }
}