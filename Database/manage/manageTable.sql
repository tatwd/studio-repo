-- --------
-- 针对`S_T`
-- --------

USE S_T

GO

-- 1.

IF OBJECT_ID('student') is NULL -- 判断`student`表是否存在
    CREATE TABLE student
    (
        sno CHAR(9) PRIMARY KEY CHECK(sno LIKE '[0-9]{9}'),
        sname CHAR(20) UNIQUE,
        ssex CHAR(2) CHECK(ssex IN('男', '女')),
        sage SMALLINT CHECK(sage BETWEEN 14 AND 38),
        sdept CHAR(20)
    )

GO

-- 2.

ALTER TABLE student
ADD sclass VARCHAR(10)

GO

-- 3.

ALTER TABLE student
DROP COLUMN sclass

GO

-- 4.

ALTER TABLE student
ALTER COLUMN sname CHAR(10)

GO

-- 5.

IF OBJECT_ID('course') IS NULL
    CREATE TABLE course
    (
        cno CHAR(4) PRIMARY KEY  CHECK(cno LIKE '[0-9]{40}'),
        cname CHAR(40),
        cpno CHAR(4),
        ccredit SMALLINT
    )

-- 6.

IF OBJECT_ID('sc') IS NULL
    CREATE TABLE sc
    (
        sno CHAR(9),
        cno CHAR(4),
        grade SMALLINT CHECK(grade BETWEEN 0 AND 100),
        PRIMARY KEY(sno, cno)
    )

GO

-- 7.

ALTER TABLE course
ADD CONSTRAINT Fk_cpno 
    FOREIGN KEY(cpno) 
    REFERENCES course(cno) 

-- 8.

ALTER TABLE sc
ADD CONSTRAINT Fk_sno
    FOREIGN KEY(sno) 
    REFERENCES student(cno)

GO

ALTER TABLE sc
ADD CONSTRAINT Fk_cno
    FOREIGN KEY(cno) 
    REFERENCES course(cno) 

GO

-- 9.

DROP TABLE student

GO

-- --------
-- 针对`company`
-- --------

USE company

GO

-- 1.
IF OBJECT_ID('employee') IS NULL
    CREATE TABLE employee
    (
        emp_no CHAR(5)NOT NULL PRIMARY KEY,
        emp_name CHAR(10) NOT NULL,
        sex CHAR(2) NOT NULL,
        dept CHAR(4) NOT NULL,
        title CHAR(6) NOT NULL,
        date_hired DATETIME NOT NULL,
        birthday DATETIME  NULL,
        salary INT NOT NULL,
        telephone VARCHAR(20) NULL,
        addr CHAR(50)  NULL,
    )

GO

IF OBJECT_ID('customer') IS NULL
    CREATE TABLE  customer
    (
        cust_id CHAR(5) NOT NULL PRIMARY KEY,
        cust_name CHAR(20) NOT NULL,
        addr CHAR(40) NOT NULL,
        tel_no CHAR(20) NOT NULL,
        zip CHAR(6) null
    )

GO

IF OBJECT_ID('sales') IS NULL
    CREATE TABLE sales
    (
        order_no INT NOT NULL PRIMARY KEY,
        cust_id CHAR(5) NOT NULL,
        sale_id CHAR(5) NOT NULL,
        tot_amt NUMERIC(9,2) NOT NULL,
        order_date DATETIME NOT NULL,
    )


IF OBJECT_ID('sale_item') IS NULL
    CREATE TABLE sale_item(
        order_no INT NOT NULL,
        prod_id CHAR(5) NOT NULL,
        qty INT NOT NULL,
        unit_price NUMERIC(7,2) NOT NULL,
        order_date DATETIME null,
        CONSTRAINT pk_sale_item PRIMARY KEY(order_no,prod_id )
    )

IF OBJECT_ID('product') IS NULL
    CREATE TABLE product(
        prod_id CHAR(5) NOT NULL PRIMARY KEY,
        prod_name CHAR(20) NOT NULL
    )

GO

-- 2.

ALTER TABLE sales
ADD invoice_no CHAR(10) NOT NULL

GO

-- 3.

-- a)

ALTER TABLE sales
ADD CONSTRAINT FK_sale_id
    FOREIGN KEY(sale_id)
    REFERENCES employee(emp_no)

GO

-- b)

ALTER TABLE sales
ADD CONSTRAINT FK_cust_id
    FOREIGN KEY(cust_id)
    REFERENCES customer(cust_id)

GO

-- c)

ALTER TABLE sale_item
ADD CONSTRAINT FK_order_no
    FOREIGN KEY(order_no)
    REFERENCES sales(order_no)

GO

-- d)

ALTER TABLE sale_item
ADD CONSTRAINT FK_prod_id
    FOREIGN KEY(prod_id)
    REFERENCES product(prod_id)

GO

-- 4.

-- a)

ALTER TABLE employee
ADD CONSTRAINT CK_salary
    CHECK(salary BETWEEN 1000 AND 10000)

GO

-- b)

ALTER TABLE employee
ADD CONSTRAINT CK_emp_no
    CHECK(emp_no LIKE '^[E][0-9]{5}')

GO

-- c)

ALTER TABLE employee
ADD CONSTRAINT CK_sex
    CHECK(sex IN('男', '女'))

GO

-- d)

ALTER TABLE sales
ADD CONSTRAINT CK_inno
    CHECK(invoice_no LIKE '^[I][0-9]{9}')

GO

-- 5.

ALTER TABLE sales
ADD CONSTRAINT UN_inno
    UNIQUE(invoice_no)

GO

-- 6.

ALTER TABLE sales
DROP COLUMN invoice_no

-- --------
-- END!
-- --------

SELECT * FROM sales