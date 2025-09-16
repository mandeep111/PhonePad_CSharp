# PhonePad Console Application

This project demonstrates a simple **Onion Architecture** implementation in a .NET Console Application.  
It follows principles of **Loose Coupling**, **Extensibility**, and **Abstraction**.  

The app simulates an **Old Phone Pad** text input system.

---

## 🛠 Project Structure
PhonePadSolution/
│── PhonePad.Domain
│── PhonePad.Application
│── PhonePad.Infrastructure
│── PhonePad.ConsoleApp


---

## 🚀 How to Run

1. **Clone the repository**  
   git clone https://github.com/your-repo/PhonePadSolution.git
   cd PhonePadSolution

2. **Clone the repository**  
    dotnet restore

3. **Build the solution**  
    dotnet build

4. **Run the Console Application**  
    dotnet run --project PhonePad.Console 

4. **Run the Console Application**  
    cd PhonePad.Tests
    dotnet test