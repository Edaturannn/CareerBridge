
<h1>CareerBridge</h1>

- Auto Mapper

- Asp.Net Core API

- OpenAI API 

- Swagger

- Postman

- Docker

- PostgreSQL

- SMTP Mail Service

- DBeaver

- API Consume

- Json Web Token

- Argon2

- Login

- Register

- Asp.Net Core 7.0

- Fluent Validation

- N Tier Architecture

- Dto Layer

- MVC

- Entity Framework Core

- Repository Design Pattern


<h4>Projenin Amacı:</h4>

Bu projenin temel amacı, kullanıcıların güvenli bir şekilde kayıt olarak sisteme giriş yapmasını ve rollerine göre yönlendirilmesini sağlamaktır. Kullanıcılar, sisteme giriş yaptıktan sonra profil bilgilerini yönetebilir, OpenAI ChatGPT servisi ile entegre çalışan interaktif kariyer danışmanlık modülü sayesinde mesleki yönelimleri hakkında destek alabilir ve kişiselleştirilmiş bir kariyer yol haritası oluşturabilirler. Böylece sistem, yapay zeka destekli danışmanlık yaklaşımı ile bireylerin kariyer planlamasını daha etkili hale getirmeyi hedeflemektedir.

<h4>Projenın Tanıtımı:</h4>

Bu projeyi ASP.NET Core 7.0, Entity Framework Core, Katmanlı Mimari (N-Tier Architecture), Code-First yaklaşımı ve RESTful API prensipleri doğrultusunda geliştirdim. Uygulamanın ölçeklenebilirliğini ve taşınabilirliğini artırmak amacıyla Docker konteyner teknolojisini kullandım. PostgreSQL veritabanını resmi Docker imajı ile izole bir konteynerde çalıştırarak, uygulamanın farklı ortamlarda tutarlı bir şekilde çalışmasını sağladım. Bu sayede veritabanı erişimi hem daha güvenli hale getirildi hem de deployment süreçleri sadeleştirildi.

Frontend tarafında, kullanıcı deneyimini ön planda tutan, duyarlı ve modern bir arayüz elde etmek amacıyla Bootstrap kütüphanesinin hazır bir temasını entegre ettim. Kimlik doğrulama ve yetkilendirme işlemlerinde, JWT (JSON Web Token) tabanlı authentication mekanizmasını uyguladım. Kullanıcı şifrelerini Argon2 hashing algoritmasıyla güvenli bir şekilde şifreleyerek sakladım. Token’ların istemci tarafında güvenli bir şekilde tutulabilmesi için HttpOnly ve Secure flag’leri aktif edilmiş Session Cookie yapısını tercih ederek, XSS ve Token Hijacking gibi saldırılara karşı koruma sağladım.

Uygulamada e-posta tabanlı kimlik doğrulama işlemlerini desteklemek adına SMTP protokolüyle çalışan bir mail servisi entegre ettim. Kullanıcılar “Şifremi Unuttum” özelliği sayesinde sistemde kayıtlı e-posta adreslerine tek kullanımlık güvenli şifre sıfırlama token’ı içeren bağlantılar alabilmekte ve yeni şifre belirleyerek hesaplarına güvenli bir şekilde erişebilmektedir.

Projeye dış servis entegrasyonu kapsamında OpenAI’nin ChatGPT API hizmetini dahil ettim. Bu servis için backend katmanında özel bir API Controller tanımladım. Kullanıcılardan gelen mesajlar, HttpClient aracılığıyla OpenAI Chat Completion API’sine yönlendirilmekte ve alınan yapay zeka yanıtları UI tarafında gerçek zamanlı olarak görüntülenmektedir. ASP.NET MVC mimarisiyle hazırladığım kullanıcı arayüzü sayesinde, kullanıcılar ChatGPT tabanlı akıllı kariyer danışmanlığı hizmetinden faydalanabilmektedir.



<img width="1439" alt="Ekran Resmi 2025-04-10 19 09 10" src="https://github.com/user-attachments/assets/549caf5a-e76b-4127-9cd1-fd1ba3f6d5f3" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 09 20" src="https://github.com/user-attachments/assets/25a60d1b-2d54-47fe-8c83-faa6240f88fc" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 11 53" src="https://github.com/user-attachments/assets/0e243de9-0d53-4458-8cd9-3b69940959c7" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 13 49" src="https://github.com/user-attachments/assets/f788a165-b82f-4ebe-a501-1c09e14da433" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 13 59" src="https://github.com/user-attachments/assets/f03fff65-ab08-4cac-a3c9-a93b66f8146d" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 14 18" src="https://github.com/user-attachments/assets/b2e4af47-20ed-45e3-bcb5-b82f79de0dab" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 15 02" src="https://github.com/user-attachments/assets/b8f83f91-7539-44a0-9398-176ddbdffdb3" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 15 26" src="https://github.com/user-attachments/assets/e3412ffb-fc20-4b26-9792-15f5a63946ff" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 16 01" src="https://github.com/user-attachments/assets/4b3d03da-6b89-483b-a027-3223552389eb" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 16 26" src="https://github.com/user-attachments/assets/1efddca7-d2ed-4102-bae1-4cce3b0f56e9" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 16 42" src="https://github.com/user-attachments/assets/bceae568-cde2-486e-8884-f504f9585103" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 17 05" src="https://github.com/user-attachments/assets/60380fa2-6ffb-4fbd-8a12-147fad2078be" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 17 26" src="https://github.com/user-attachments/assets/4ea6937b-e010-4ac0-ac82-9a4b263d1fca" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 17 13" src="https://github.com/user-attachments/assets/3dc1ab8f-1acf-4fec-b747-826c888f50eb" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 22 27" src="https://github.com/user-attachments/assets/778441ef-80bb-496c-b3fe-e39e716af551" />

<img width="1439" alt="Ekran Resmi 2025-04-10 19 21 48" src="https://github.com/user-attachments/assets/018c005b-bae7-46cc-8224-44bc8a320cf5" />



