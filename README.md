# MATLID - Modern Artistic Trends in Lifestyle & Design

Welcome to **MATLID**, your destination for exploring cutting-edge artistic trends in lifestyle, fashion, design, and home decor!

## About MATLID

MATLID is a dynamic platform dedicated to curating and showcasing the latest trends in lifestyle and design. We focus on promoting creativity and innovation in everyday living, from fashion to home decor. Whether you’re a designer, artist, or enthusiast, MATLID is your go-to place for inspiration and trendsetting ideas.

## Features

- **Trendy Collections**: Curated collections of modern lifestyle products and designs.
- **Inspiration Gallery**: A visual gallery featuring the works of talented designers and artists.
- **Blog**: Dive deep into the world of lifestyle and design with insightful articles and blog posts.
- **Community Engagement**: Join a thriving community to share ideas, tips, and experiences with like-minded individuals.

## Key Features

- **Explore Artistic Trends**: Stay updated with the latest trends in art and design.
- **Creative Community**: Connect with artists and designers, exchange ideas, and collaborate.
- **In-depth Articles**: Read detailed articles analyzing trends in art, fashion, and lifestyle.
- **Ratings and Comments**: Engage with content by rating and commenting on articles and trends.

## Architecture and Technologies Used

MATLID is powered by modern technologies to provide a smooth user experience, scalability, and security. Here’s an overview of the stack:

### Frontend

- **Language**: TypeScript
- **Framework**: Angular 16
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
CQRS helps separate write (Command) and read (Query) operations, making the application more efficient and scalable. It helps maintain a clear distinction between data processing and retrieval.

#### Repository Pattern
The Repository Pattern abstracts the data access layer, making it easier to maintain and extend the application’s data management.

#### Validators
FluentValidation is used to ensure data integrity by validating user inputs before they are processed by the server.

## Installation and Running the Project

### System Requirements

- **.NET 6 SDK**
- **Angular version 16.2.0**
- **Node.js** (latest version)
- **SQL Server | Oracle database**

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/phamtiendungcw/MatLidStore.git
   cd MatLidStore
   ```

2. **Install dependencies for Backend**
   ```bash
   cd MLS.Api
   dotnet restore
   ```

3. **Install dependencies for Frontend**
   ```bash
   cd ../MLS.MatLidStoreUI
   npm install
   ```

## Running the Application

1. **Run the Backend**
   ```bash
   cd MLS.Api
   dotnet run
   ```

2. **Run the Frontend**
   ```bash
   cd ../MLS.MatLidStoreUI
   ng serve
   ```

## Access the Application

Open your browser and navigate to [https://localhost:4200](https://localhost:4200) to start exploring MATLIDSTORE.

## Contribute

We welcome contributions from everyone passionate about modern artistic trends. If you'd like to contribute, please follow the instructions in our [Contributing Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the GNU GENERAL PUBLIC LICENSE. See the [LICENSE](LICENSE) file for more details.

## Contact Us

- **Website**: [www.matlid.com](https://www.matlid.com)
- **Email**: [info@matlid.com](mailto:info@matlid.com)
- **Email**: [phamtiendungcw@gmail.com](mailto:phamtiendungcw@gmail.com)

Thank you for visiting MATLID – Where Art Meets Lifestyle!