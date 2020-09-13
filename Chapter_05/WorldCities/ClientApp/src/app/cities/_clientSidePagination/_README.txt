
The files contained in this folder have been added in 2020.09.13 to fix the "client-side pagination" technique of the MatPaginator component in book's Chapter 5
(pages 224-226), before it gets replaced with the server-side pagination technique within that same chapter later on.

In order to make them work, do the following:

- replace the cities.component.html and cities.components.ts files in the /ClientApp/sec/app/Cities/ folder with the corresponding files contained in this folder.
- patch the GetCities() method in the /Controllers/CitiesController.cs file in the following way:

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

IMPORTANT: the "client-side pagination" technique is way less efficient than its "server-side" counterpart and has only been added there for demostration purposes:
see GitHub issue #16 ( https://github.com/PacktPublishing/ASP.NET-Core-3-and-Angular-9-Third-Edition/issues/16 ) for further details.
