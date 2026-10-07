namespace Application.Interfaces.Security;
public interface IPasswordHasher
{
    // 🎯 將明文密碼轉化為不可逆的雜湊字串（用於註冊、修改密碼）
    string HashPassword(string password);

    // 🎯 比對前端傳入的明文密碼，與資料庫儲存的雜湊值是否相符（用於登入）
    bool VerifyPassword(string password, string hashedPassword);
}
