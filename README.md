# BootTelegram
Boot Desenvolvido em DotNet 6.0, MySQL, Clean Architecture, integrado com o TELEGRAM, para manipular, ler e enviar dados de grupos.

Ex:
Preciso copiar informações do GRUPOA / GRUBOB, trocando algumas palavras ou textos .. 

Pré requisitos:

1: - Necessário configurar uma variavel no appsettings: "ConnectionMySql:ConnectionString"
2: - Necessário configurar essas variáveis:
            "TelegramConfig:ApiHash"];
            "TelegramConfig:ApiId"]; 
            "TelegramConfig:PhoneNumber"];
            "TelegramConfig:Password"];
            "TelegramConfig:FirstName"];
            "TelegramConfig:LastName"];
            "TelegramConfig:VerificationCode"];

Obs: Esses dados devem ser obtidos no site do telegram e também na documentação da lib: WTelegramClient => https://github.com/wiz0u/WTelegramClient

3: - Necessário rodar o migrations do EF

