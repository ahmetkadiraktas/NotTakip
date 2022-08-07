SELECT * FROM Donem1

SELECT ROUND(CAST(SUM(ECTScredits*GPA) AS float) / CAST(SUM(ECTScredits) AS float), 2) AS Avr FROM Donem1