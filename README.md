# CP.Final.Mincifra
Модуль визуализации и навигации по данным, находящимся в государственных информационных системах
<!--
*** Thanks for checking out this README Template. If you have a suggestion that would
*** make this better please fork the repo and create a pull request or simple open
*** an issue with the tag "enhancement".
*** Thanks again! Now go create something AMAZING! :D
-->





<!-- PROJECT SHIELDS -->
[![Build Status][build-shield]]()
[![Contributors][contributors-shield]]()
[![MIT License][license-shield]][license-url]



<!-- PROJECT LOGO -->
<br />


  <h3 align="center">README</h3>

  <p align="center">
    README !
    <br />
    <a href="https://github.com/nkiruhin/CP.Final.Mincifra/blob/master/README.md"><strong>Этот документ »</strong></a>
    <br />
    <br />
    <!--<a href="https://github.com/othneildrew/Best-README-Template">View Demo</a>-->
    ·
    <a href="https://github.com/nkiruhin/CP.Final.Mincifra/issues">Report Bug</a>
    ·
    <a href="https://github.com/nkiruhin/CP.Final.Mincifra/issues">Request Feature</a>
  </p>
</p>



<!-- TABLE OF CONTENTS -->
## Table of Contents

* [О проекте](#about-the-project)
  * [Технологии](#built-with)
* [Запуск приожения](#getting-started)
  * [Необходимые условия](#prerequisites)
  * [Установка](#installation)
  * [Запуск](#start)
* [Использование](#usage)
* [Сопутствующие](#contributing)
* [License](#license)
* [Contact](#contact)



<!-- ABOUT THE PROJECT -->
## О проекте
Сервис разработан в рамках финального хакатона конкурса "Цифровой прорыв 2020"
Команда Aurora
![image](https://user-images.githubusercontent.com/39044526/100528055-d415a600-31f1-11eb-8b3a-1679396db48f.png)
### Технологии

* [ASP.Net Core](https://github.com/dotnet/core)
* [React](https://reactjs.org/)
* [TypeScript](https://www.typescriptlang.org/)



<!-- GETTING STARTED -->
## Старт

Раздел содержит информацию по разворачиванию сервиса
<p>
Скачайте и установите .NET Core SDK на компьтер.
<p>

### Необходимые условия

Необходимые условия для этого проекта вы можете найти по ссылкам
.Net Core 3.1

for Windows:
https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?pivots=os-windows&tabs=netcore31

for Linux:
https://docs.microsoft.com/en-us/dotnet/core/install/dependencies?pivots=os-linux&tabs=netcore31

Node.js
https://nodejs.org/en/download/


### Установка

1. Клонирование репозитория
```sh
git clone https://github.com/nkiruhin/KavkazHub.Remont.git
```


## Старт

```sh
dotnet restore "src/CP.Final.Mincifra.Web/CP.Final.Mincifra.Web.csproj"
```
```sh
dotnet build "CP.Final.Mincifra.Web.csproj" -c Release -o /app/build
```
```sh
cd "src/CP.Final.Mincifra.Front"
npm install
npm start
```

<!-- USAGE EXAMPLES -->
## Использование


Документация swagger open api будет доступна по адресу http://localhost:5000/swagger/index.html



<!-- CONTRIBUTING -->
## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact


Project Link: [https://github.com/nkiruhin/CP.Final.Mincifra](https://github.com/nkiruhin/CP.Final.Mincifra)









<!-- MARKDOWN LINKS & IMAGES -->
[build-shield]: https://img.shields.io/badge/build-passing-brightgreen.svg?style=flat-square
[contributors-shield]: https://img.shields.io/badge/contributors-1-orange.svg?style=flat-square
[license-shield]: https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square
[license-url]: https://choosealicense.com/licenses/mit
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/othneildrew
[product-screenshot]: https://raw.githubusercontent.com/othneildrew/Best-README-Template/master/screenshot.png

