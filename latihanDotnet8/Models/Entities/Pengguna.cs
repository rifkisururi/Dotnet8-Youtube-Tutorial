namespace latihanDotnet8.Models.Entities
{
    public class Pengguna
    {
        public Guid Id { get; set; } = new Guid();
        public string? Name { get; set; }
        public string Email { get; set; }
        public string NoHp { get; set; }
        public string Pin { get; set; } = "123456";
        public string Password { get; set; }
        public int PasswordSalah { get; set; } = 0;
        public int pinSalah { get; set; } = 0;
        public bool isActive { get; set; } = true;

    }
}
