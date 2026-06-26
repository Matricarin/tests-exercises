**Задача 3: Анализ и оптимизация запроса**

* **Задача:** Дана таблица `Orders (Id, UserId, Status, CreatedAt)` на 1 млн строк. 
Запрос `SELECT * FROM Orders WHERE Status = 'Pending' ORDER BY CreatedAt DESC LIMIT 10` работает медленно. 
Проанализируй проблему и напиши `CREATE INDEX`.

* **Валидация:** Выполни `EXPLAIN ANALYZE` до и после создания индекса. 
Убедись, что `Sequential Scan` сменился на `Index Scan Backward` или `Index Scan`.

**Что важно:**
