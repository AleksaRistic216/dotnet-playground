DROP PROCEDURE IF EXISTS InsertMockData;

ALTER TABLE "Users" SET UNLOGGED;

CREATE PROCEDURE InsertMockData()
LANGUAGE plpgsql
AS $$
DECLARE
    i         INTEGER;
    j         INTEGER;
    values_list TEXT;
    sql_query   TEXT;
    city      TEXT;
    country   TEXT;
    phone     TEXT;
BEGIN
    FOR i IN 1..10000 LOOP
        city := CASE MOD(i, 20)
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
                END;
        country := CASE MOD(i, 5)
                       WHEN 0 THEN 'Serbia'
                       WHEN 1 THEN 'Bulgaria'
                       WHEN 2 THEN 'Romania'
                       ELSE 'Austria'
                   END;
        values_list := '';  

        FOR j IN 1..1000 LOOP
            phone := '+' || floor(random() * 10000000000)::bigint::text;
            
            IF j > 1 THEN
                values_list := values_list || ', ';
            END IF;
            
            values_list := values_list || FORMAT(
                '(%L, %L, %L, %L, %L, %L, %s, %s, %s, CURRENT_TIMESTAMP, %s)',
                CONCAT('User_', i, '_', j),
                city,
                country,
                CONCAT('user_', i, '_', j, '@example.com'),
                phone,
                CONCAT(i::text, 'th Street'),
                floor(random() * (40000 - 10000) + 10000)::int,
                floor(random() * (60 - 18) + 18)::int,
                (i % 2 = 0)::text,
                0
            );
        END LOOP;
        
        sql_query := 'INSERT INTO "Users" ("Name", "City", "Country", "Email", "Phone", "Address", "PostalCode", "Age", "IsActive", "CreatedAt", "CreatedBy") VALUES ' 
                     || values_list || ';';
        
        RAISE NOTICE 'Executing: %', sql_query;
        EXECUTE sql_query;
    END LOOP;
END $$;

CALL InsertMockData();

ALTER TABLE "Users" SET LOGGED;
REINDEX TABLE "Users";
