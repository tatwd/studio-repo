-- --------
-- 针对`S_T`
-- --------

USE S_T

GO

-- 1.

ALTER TABLE student
ADD CONSTRAINT CK_sage
    CHECK(sage BETWEEN 14 AND 38)

GO

-- 2.

ALTER TABLE course
ADD CONSTRAINT UN_cname
    UNIQUE(cname)

GO

-- 3.

ALTER TABLE sc
ADD DEFAULT(0) FOR grade

GO

-- 4.

ALTER TABLE course
DROP CONSTRAINT UN_cname

GO

-- 5.

INSERT INTO student
VALUES('200215121', 'Mary', '女', 18, 'CS')

GO

-- 6.

INSERT INTO sc
VALUES('20021525', '1', 87)

GO

-- 7.

INSERT INTO student
VALUES('200215125', 'Mary', '女', 40, 'CS')

GO

-- 8.

UPDATE student
SET sno = '200215125'
WHERE sno = '200215121'

GO

-- 9.

UPDATE sc
SET sno = '200215125'
WHERE sno = '200215121'
    AND cno = '1'

GO

-- 10.

UPDATE sc
SET grade = 120
WHERE sno = '200215121'
    AND cno = '1'

GO

-- 11.

DELETE FROM student
WHERE sno = '200215121'

GO

-- --------
-- 针对`coampany`
-- --------

USE company

GO

-- 1.

ALTER TABLE employee
ADD CHECK(salary <= 10000)

GO

-- 2.

ALTER TABLE sales
ADD FOREIGN KEY(sale_id)
    REFERENCES employee(emp_no)

GO

-- 3.

ALTER TABLE sales
ADD FOREIGN KEY(cust_id)
    REFERENCES customer(cust_id)

GO

-- 4.

INSERT INTO product
VALUES('P0014', '激光机')

GO

-- 5.

UPDATE sales
SET sale_id = 'E0021'
WHERE order_no = '10001'

GO

-- 6.

UPDATE employee
SET salary = 12000
WHERE emp_no = 'E0001'

GO

-- 7.

UPDATE employee
SET salary = salary + salary * 0.1

GO

-- 8.

DELETE sales 
FROM sales, sale_item
WHERE sale_id = '10007'
    AND sales.order_no = sale_item.order_no 

-- 9.

DELETE employee
FROM employee
WHERE NOT EXISTS(
    SELECT sale_id
    FROM sales
    WHERE employee.emp_no = sales.sale_id
)

GO

-- 10.

UPDATE employee
SET salary = salary + 500
WHERE emp_no IN(
    SELECT sale_id
    FROM sales
    WHERE tot_amt > 20000 -- 只有一笔即可
)

-- --------
-- END!
-- --------