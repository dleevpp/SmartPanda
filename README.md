# SmartPanda
스마트폰 및 스마트워치용 액세서리 전문 쇼핑몰 애플리케이션

## 실행 방법
```
cd ./WhiteFoot
yarn serve
```
```
cd ./BlackFoot
rm db.sqlite
dotnet ef migrations remove
dotnet ef migrations add <migraion 이름>
dotnet ef database update
dotnet run
```
## URI
- 프론트엔드: http://localhost:8080/
- 백엔드: https://localhost:5001/api/
