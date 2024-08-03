# MATLID - Modern Artistic Trends in Lifestyle & Design

Welcome to MATLID, where we explore modern artistic trends in lifestyle and design!

## About MATLID

MATLID is a dynamic platform dedicated to curating and showcasing the latest trends in lifestyle and design. From fashion to home decor, we celebrate creativity and innovation that enhances everyday living.

## Features

- **Trendy Collections:** Explore curated collections of modern lifestyle products and designs.
- **Inspiration Gallery:** Get inspired by our gallery featuring the work of talented designers and artists.
- **Blog:** Dive deeper into the world of lifestyle and design with our insightful blog posts and articles.
- **Community Engagement:** Join our community to share ideas, tips, and experiences with like-minded individuals.

## How to Use

1. **Explore:** Browse our website to discover the latest trends and collections.
2. **Get Inspired:** Check out our inspiration gallery for ideas and creativity.
3. **Connect:** Join our community and engage with fellow enthusiasts.
4. **Stay Updated:** Follow us on social media for the latest news and updates.

## Key Features

- **Explore Artistic Trends**: Stay updated with the latest trends in art and design.
- **Creative Community**: Connect with other artists and designers, share, and discuss new ideas.
- **In-depth Articles**: Read detailed articles analyzing trends in art and lifestyle.
- **Ratings and Comments**: Rate and comment on articles and trends, and participate in community discussions.

## Architecture and Technologies Used

The MATLID project is built using advanced technologies to ensure high performance, security, and easy maintenance. Below are the languages and architectures used:

### Frontend

- **Language**: TypeScript
- **Framework**: Angular 14
- **Styling**: SCSS (Sass)
- **State Management**: NgRx
- **HTTP Client**: HttpClient (Angular)

### Backend

- **Language**: C#
- **Framework**: ASP.NET Core 6
- **Architecture**: Clean Architecture with CQRS pattern
- **ORM**: Entity Framework Core
- **Database**: SQL Server | Oracle

### Application Architecture

#### CQRS (Command Query Responsibility Segregation)

CQRS helps separate the write (Command) and read (Query) operations in the application, providing clear separation between data processing logic and data retrieval logic. Entities like Product, Order, User, Article, etc., are implemented using the CQRS pattern with Data Transfer Objects (DTOs) for CRUD operations.

#### Repository Pattern

The Repository Pattern is used to manage data access, creating an abstraction layer between the application and the database, making maintenance and expansion of the application easier.

#### Validators

FluentValidation is used for data validation, ensuring that the data sent to the server is always valid and reliable.

## Installation and Running the Project

### System Requirements

- .NET 6 SDK
- Node.js (latest version)
- SQL Server

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/phamtiendungcw/MatLidStore.git
   cd MatLidStore

2. **Install dependencies for Backend**
   ```bash
   cd MLS.Api
   dotnet restore

4. **Install dependencies for Frontend**
   ```bash
   cd ../MLS.WebUI
   npm install

## Running the Application
1. Run backend
   ```bash
   cd MLS.Api
   dotnet run

3. Run Frontend
   ```bash
   cd ../MLS.WebUI
   ng serve

## Access the Application

Open your browser and go to http://localhost:4200 to start exploring MATLID.

## Contribute

We welcome contributions from designers, artists, and enthusiasts passionate about modern artistic trends. If you'd like to collaborate or contribute to MATLID, please reach out to us.

## Contact Us

- **Website:** [www.matlid.com](https://www.matlid.com)
- **Email:** info@matlid.com
- **Email:** phamtiendungcw@gmail.com

Thank you for visiting MATLID - Where Art Meets Lifestyle!
