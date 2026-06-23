with recursive parents as(
    select
        Id,
        Name,
        ParentId
    from Categories
    where Id = 5
    union
    select
        Categories.Id,
        Categories.Name,
        Categories.ParentId
    from Categories
             join parents
                  on parents.ParentId = Categories.Id
)
SELECT  * from parents;