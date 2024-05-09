# HTMX Todo App 2024

I typically do these sample applications just to see if my impressions of technologies
still hold up to a revisit. This time it's Razor Pages with HTMX and my own library of HTMX.NET.

## Getting Started

You'll want to first restore the EF Core tools with

```bash
dotnet tool restore
```

then run

```bash
dotnet ef database update
```

Now you can run the application.

## What is it?

It's a simple Todo application that saves elements to a database and re-renders the page with the changes. It's designed in a way that every user action will update the UI accordingly.

## Licence

MIT License

Copyright (c) 2024 Khalid Abuhakmeh
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.