namespace CarWash.Models
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarWash carWash = new CarWash();

            Voiture v1 = new Voiture("1-VPE-062");
            Voiture v2 = new Voiture("1-FDE-042");

            carWash.Traiter(v1);
            carWash.Traiter(v2);

            CarWashV2 carWashV2 = new CarWashV2();
            carWashV2.Traiter(v1);
            carWashV2.Traiter(v2);
        }
    }
}
