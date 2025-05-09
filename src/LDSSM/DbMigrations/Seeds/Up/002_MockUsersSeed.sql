DROP PROCEDURE IF EXISTS InsertMockData;

CREATE PROCEDURE InsertMockData()
LANGUAGE plpgsql
AS $$
BEGIN
    FOR i IN 1..10000 LOOP
    RAISE NOTICE 'Inserting record %', i;
    INSERT INTO "Users"
    ("Name", "City", "Country", "Email", "Phone", "Address", "PostalCode", "Age", "IsActive", "CreatedAt", "CreatedBy")
VALUES (
    CONCAT('User_', i),
    CASE MOD(i, 20)
WHEN 0 THEN 'Belgrade'
WHEN 1 THEN 'Novi Sad'
WHEN 2 THEN 'Niš'
WHEN 3 THEN 'Kragujevac'
WHEN 4 THEN 'Subotica'
WHEN 5 THEN 'Sofia'
WHEN 6 THEN 'Plovdiv'
WHEN 7 THEN 'Varna'
WHEN 8 THEN 'Bucharest'
WHEN 9 THEN 'Cluj-Napoca'
WHEN 10 THEN 'Timisoara'
ELSE 'Prague'
END,
CASE MOD(i, 5)
WHEN 0 THEN 'Serbia'
WHEN 1 THEN 'Bulgaria'
WHEN 2 THEN 'Romania'
ELSE 'Austria'
END,
CONCAT('user_', i, '@example.com'),
CONCAT('+', FLOOR(RANDOM() * 10000000000)), 
CONCAT(i, 'th Street'),
FLOOR(RANDOM() * (40000 - 10000) + 10000),
FLOOR(RANDOM() * (60 - 18) + 18),
(i % 2 = 0),
current_timestamp,
0
    );
END LOOP;
END $$;

CALL InsertMockData();