namespace WebApplication2.Models
{
    public class User
    {
        public int id { get; set; }  // ユーザーID
        public string username { get; set; }  // 名前
        public string email { get; set; }  // メールアドレス
        public string password_hash { get; set; } // パスワード
        public DateTime? created_at { get; set; } // 作成日時
    }
}
