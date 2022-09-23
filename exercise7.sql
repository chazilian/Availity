--Assumption being made is that the OrderLine cost is the sum of the order. 

--a
SELECT *
FROM Customer
WHERE LastName like 's%'
ORDER BY FirstName DESC, LastName DESC

--b
SELECT c.CustID, c.FirstName, c.LastName, COALESCE(SUM(ol.Cost * ol.Quantity), 0) as totalOrder
FROM Customer c
LEFT JOIN Order o ON c.CustID = o.CustomerID AND o.OrderDate >= DATEADD(month, -6, GETDATE()) 
LEFT JOIN orderLine ol ON ol.OrdID = o.OrderID
GROUP BY c.CustID, c.FirstName, c.LastName

--c
SELECT c.CustID, c.FirstName, c.LastName, COALESCE(SUM(ol.Cost * ol.Quantity), 0) as totalOrder
INTO #CustomersTotalOrder
FROM Customer c
LEFT JOIN Order o ON c.CustID = o.CustomerID AND o.OrderDate >= DATEADD(month, -6, GETDATE()) 
LEFT JOIN orderLine ol ON ol.OrdID = o.OrderID 
GROUP BY c.CustID, c.FirstName, c.LastName

SELECT * 
FROM #CustomersTotalOrder
WHERE 100 < totalOrder AND totalOrder < 500