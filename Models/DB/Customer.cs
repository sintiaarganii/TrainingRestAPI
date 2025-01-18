namespace Training2.Models.DB

{
    public class Customer
    {
        //[Key] public int Id_cus { get; set; } //jika bkn id saja dan bakal jadi auto inc
        public int id {  get; set; } //field akan auto_incerement dan primary key
        public string nama { get; set; }
        public string alamat {  get; set; }
        public string city { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
