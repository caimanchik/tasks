# Проект для курса по проектированию микросервисов
## Как запустить?
```cmd
cd Host/AppHost

dotnet run https
```

Предварительно должен быть установлен и запущен Docker

## Как завести авторизацию?

1. Запустить
2. [Перейти в Keycloak](http://localhost:10001/)
3. Авторизоваться(админские секреты настраиваются [здесь](https://github.com/caimanchik/tasks/blob/bbad076880888a3885bf5a525a503787f33c1077/Host/AppHost/appsettings.json#L11)) и создать новый realm
<img width="1345" alt="Снимок экрана 2025-01-03 в 09 11 38" src="https://github.com/user-attachments/assets/4a8727de-0464-4009-9c0f-aaef78b4a5d6" />

4. Разрешить регистрацию
<img width="562" alt="Снимок экрана 2025-01-03 в 09 12 34" src="https://github.com/user-attachments/assets/35179895-db4d-4511-ab22-af5d4cf7ca1d" />

5. Создать клиента

<img width="1624" alt="Снимок экрана 2025-01-03 в 09 13 39" src="https://github.com/user-attachments/assets/4e6d0c87-b2f0-4cba-8fa4-8a5568f20f7e" />

<img width="1025" alt="Снимок экрана 2025-01-03 в 09 14 19" src="https://github.com/user-attachments/assets/c8c107fe-289a-423c-a991-dcbed61e94f4" />

<img width="1025" alt="Снимок экрана 2025-01-03 в 09 15 41" src="https://github.com/user-attachments/assets/995c0456-b9d3-4655-9372-944de27a4112" />

6. Указать созданный realm в [настройках](https://github.com/caimanchik/tasks/blob/main/Services/Tasks/src/Api.Tasks/appsettings.json)
