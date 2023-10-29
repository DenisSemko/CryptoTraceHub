<img src="https://github.com/DenisSemko/CryptoTraceHub/assets/53062219/bc995bf3-b609-4e11-9c8f-6edadb659805" alt="logo" title="logo" align="right" height="100" />

# CryptoTraceHub
> Go-to solution for staying up-to-date with the dynamic world of cryptocurrencies. With its intuitive design and powerful features, CryptoTraceHub simplifies the way you monitor cryptocurrencies prices.

## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Architecture](#architecture)
* [Features](#features)
* [Screenshots](#screenshots)
* [Setup](#setup)
* [Usage](#usage)
* [Project Status](#project-status)
* [Contact](#contact)
* [License](#license)

## General Information
CryptoTraceHub is your all-in-one solution for cryptocurrency enthusiasts. Stay updated on crypto prices. 
Simplify your crypto journey with CryptoTraceHub today!

## Technologies Used
- Web Application - React.js
- Back-end: .NET 7, C#
- Containerization: Docker
- Database: PostgreSQL
- Third-party-api: CoinMarketCapApi
- Microservices
- Microservices Communication - RabbitMQ via MassTransit
- Unit Testing: xUnit

## Architecture

![image](https://github.com/DenisSemko/CryptoTraceHub/assets/53062219/50f38d05-4eb5-45b4-bf4b-21b947c2da37)


## Features
- Get Listings with additional query parameters;
- Get Quotes with additional query parameters;
- Get Price Conversion.

## Screenshots
<p><i>Back-end</i></p>
<img width="1425" alt="Screenshot 2023-10-29 at 18 24 28" src="https://github.com/DenisSemko/CryptoTraceHub/assets/53062219/f94f33d0-244c-43db-ad13-dfba6ecfde77">

## Setup
Project is built locally and it uses SSL certificate to run the Web App securely.

Make sure you have installed and configured [docker](https://docs.docker.com/desktop/install/windows-install/) in your environment. After that, you need to run the below commands from the /src/ directory.

`docker-compose build`
`docker-compose up`

*Another Approach:*

You need to download this repository and run it using Visual Studio 2019 or newer version or any other IDE that is suitable for you.

You can run the Web application via installing all the dependencies with the command `npm install`.

> You need to make sure you have installed PostgreSQL & RabbitMQ locally or via Docker.

## Usage
You can choose how to run the project: locally with IDE or via Docker. Both approaches work as expected. <br/>
> **NOTE:** Make sure you've configured ApiKey and BaseUrl to use CoinMarketCap API.

## Project Status
_v1.0 has not been released yet_

## Contact
Created by [@dench327](https://www.linkedin.com/in/denis-semko-551b91191) - feel free to contact me!

© 2023

## License
> You can check out the full license [here](https://github.com/DenisSemko/CryptoTraceHub/blob/master/LICENSE).
This project is licensed under the terms of the MIT license.
