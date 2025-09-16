📱 Phone Pad Processing Architecture (.NET / Onion Architecture)
Overview

This project implements a configurable phone pad text input system that converts numeric keypad sequences into text, inspired by old T9 input systems.
The solution follows Onion Architecture with a focus on SOLID principles, loose coupling, and extensibility.

🏗️ Onion Architecture Layers
1. Domain Layer (Core business rules, no dependencies)

PhoneKey – Record representing a mapping of digit → letters

IKeyMap – Interface for key-to-letter mappings

IProcessingRules – Interface defining rules (flush, backspace, valid inputs)

IPhonePad – Abstraction for the main PhonePad processor

👉 This layer is pure C# (no framework dependencies).

2. Application Layer (Use cases, orchestration)

BufferProcessor – Manages character buffering and cycling (e.g., 222 → C)

InputProcessorImpl – Orchestrates processing using injected IKeyMap and IProcessingRules

PhonePadBuilder – Fluent builder for constructing configured IPhonePad instances

👉 This layer implements application logic, depends only on Domain.

3. Infrastructure Layer (Concrete implementations)

Key Maps

OldPhonePadKeyMap – Traditional keypad (2 → ABC, 3 → DEF, etc.)

Rules

OldPhonePadRules – Classic phone behavior (# flush, * backspace)

ModernPhonePadRules – Alternative ruleset for extensibility

👉 This layer provides strategies / implementations that can be swapped in.

4. Presentation Layer (Console / UI / API)

Console App (Program.cs) – Entry point for running demos or manual tests

Unit Tests – Verify Domain & Application logic (xUnit or NUnit)

👉 This layer is where dependencies are wired up using the Builder Pattern.

🔄 Processing Flow
Input String → InputProcessorImpl → BufferProcessor → Output String
                     ↓                     ↓
            ProcessingRules           KeyMap (digit → letters)


Input Processing: Each character is evaluated via IProcessingRules

Character Handling:

Flush (# / space) → Buffer converted to a letter and appended

Backspace (*) → Buffer flushed, last character removed

Valid digit (2–9) → Appended to buffer (cycled letters)

Buffer Management: BufferProcessor ensures correct letter mapping


🧩 Key Design Patterns

Onion Architecture → Clear separation of concerns

Strategy Pattern → IProcessingRules allows multiple rule behaviors

Factory/Builder Pattern → PhonePadBuilder simplifies configuration

Dependency Injection → Components depend only on abstractions

Open/Closed Principle → New key maps / rules can be added without modifying core