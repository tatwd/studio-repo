-- --------
-- 针对`S_T`
-- --------

USE S_T

GO

-- 1.

CREATE VIEW CS_S1 -- 创建视图
AS
SELECT student.sno, sname, grade
FROM student, sc
WHERE sdept = 'CS'
    AND student.sno = sc.sno

GO

SELECT * FROM CS_S1 -- 查询视图

GO

-- 2.

CREATE VIEW CS_S2
AS
SELECT student.sno, sname, grade
FROM student, sc
WHERE sdept = 'CS'
    AND grade > 90
    AND student.sno = sc.sno

GO

SELECT * FROM CS_S2

GO

-- 3.

CREATE VIEW S_G
AS
SELECT student.sno, 
    AVG(grade) AS avg_grade
FROM student, sc
WHERE student.sno = sc.sno
GROUP BY student.sno

GO

-- 4.

SELECT * 
FROM S_G
WHERE s_g.avg_grade > 85

GO

-- 5.

CREATE VIEW F_stu
AS
SELECT *
FROM student
WHERE ssex = '女'
WITH CHECK OPTION

GO

-- 6.

INSERT INTO F_stu
VALUES('20021525', 'Jack', '男', 20, 'IS')

GO

-- 7.

CREATE VIEW stu_sc
AS
SELECT student.sno, sname, ssex, sage, sdept, cno, grade
FROM student, sc
WHERE student.sno = sc.sno

GO

-- 8.

UPDATE stu_sc
SET sage = 21
WHERE sno = '200215122'

GO

UPDATE stu_sc
SET grade = 95
WHERE sno = '200215122'
    AND cno = '2'

GO

-- 9.

INSERT INTO stu_sc(sno, sname, ssex, sage, sdept, cno, grade)
VALUES('200215128', 'Leo', '男', 21, 'CS', 1, 98)

GO

-- 10.

DROP VIEW stu_sc, CS_S1, CS_S2, F_stu, S_G

GO

-- --------
-- 针对`company`
-- --------

USE company

GO

-- 1.

CREATE VIEW cust_view
AS
SELECT cust_id, cust_name, addr
FROM customer
WHERE addr = '上海市'

GO

-- 2.

INSERT INTO cust_view
VALUES('C0008', 'Leo', '南昌市')

GO

-- 3.

CREATE VIEW cust_view
AS
SELECT cust_id, cust_name, addr, tel_no
FROM customer
WHERE addr = '上海市'

GO

-- 4.

-- TODO

-- --------
-- END!
-- --------

SELECT * FROM customer
-- SELECT * FROM 