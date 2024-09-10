# Wiki Application

### Overview
This application is designed to manage information about various Data Structures by allowing users to store, add, edit, save, and load data from a binary file. It provides an efficient way to handle and maintain data related to different Data Structures. Built using the Windows Forms Application Framework and .NET Core, it ensures a user-friendly interface and robust performance.

### Features
 - **Add New Data Structure:** Allows users to easily add new Data Structures, including specifying key attributes and properties.
   * Name: The name of the Data Structure (e.g., Stack, Queue, Binary Tree).
   * Category: Classify the Data Structure into the following categories: Array, List, Hash, Tree, Graph, and Abstract.
   * Structure: Identify the structure type as either Linear or Non-Linear.
   * Definition: Provide a brief description or definition of the Data Structure.
 - **Edit Existing Data Structure:** Users can modify the attributes of previously saved Data Structures to keep the information current. Except for the structure type attribute, it can be Linear or Non-Linear only.
 - **Save and Load Data:** Automatically saves all Data Structure information in a binary file format when exiting the application or when the Save button is pressed, ensuring efficient storage and retrieval. Additionally, the application supports saving and loading data in other file formats, though the binary format remains the default option for optimal performance.
 - **Search Functionality:** Users can search for specific Data Structures by name or other properties for quick access.
 - **Delete Data Structures:** Allows users to remove unwanted or obsolete Data Structures from the list.
 - **User-Friendly Interface:** The Windows Forms interface provides an intuitive and easy-to-navigate environment for managing Data Structures.
 - **Efficient Binary Storage:** Data is stored in a compact binary file format, optimizing performance and space usage.

### Technologies Used
- **Programming Languages:** C#
- **Frameworks:** .NET Core, Windows Forms
- **Storage:** Binary file format (default), with optional support for other formats (e.g., XML, JSON)
- **Other Tools:** GitHub for version control, Visual Studio as the integrated development environment (IDE)
