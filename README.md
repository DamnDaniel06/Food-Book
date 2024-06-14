# Food-Book

## Description
This C# command-line application allows users to enter and store the ingredients and steps for a single recipe. It also provides functionality to scale the recipe, reset quantities, and clear all data for entering a new recipe.

## Prerequisites
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or later with .NET desktop development workload

## Installation
1. Clone the repository:
  https://github.com/DamnDaniel06/Food-Book
2. Open the solution file `Food-Book.sln` in Visual Studio.

## Instructions to Compile and Run
1. Open the `Food-Book.sln` solution file in Visual Studio.
2. Build the solution by selecting `Build > Build Solution` or pressing `Ctrl+Shift+B`.
3. Run the application by selecting `Debug > Start Debugging` or pressing `F5`.

## Functionality
- Enter details for a single recipe, including the number of ingredients, name, quantity, and unit of measurement for each ingredient, and the number of steps with descriptions.
- Display the full recipe, including ingredients and steps, in a neat format.
- Scale the recipe by a factor of 0.5 (half), 2 (double), or 3 (triple), adjusting all ingredient quantities accordingly.
- Reset quantities to the original values.
- Clear all data to enter a new recipe.

## Updates Based on Feedback
- Added sufficient commits to ensure clear version history and changes.
- Enabled users to scale recipe quantities by factors of 0.5, 2, or 3.
- Enabled users to reset ingredient quantities to their original values.

## New Features
- Users can now enter the name of each recipe.
- Recipes are displayed in alphabetical order by name.
- Users can enter calories and food group for each ingredient.
- The application calculates and displays the total calories for each recipe.
- Recipes are stored in a generic collection (list) for better management.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the [MIT License](LICENSE).
