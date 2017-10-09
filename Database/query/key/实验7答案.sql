--针对S_T数据库
--1.	查询所选课程的平均成绩大于刘晨的平均成绩的学生学号、姓名及平均成绩；
select  a.sno ,sname,avg(grade)
from student a,sc b
where a.sno=b.sno 
group by a.sno,sname
having avg(grade) > 
       (select avg(grade) 
       from student a,sc b 
	   where a.sno=b.sno and sname='刘晨')
--2.	列出选修了两门课程的学生的学号、姓名、院系及成绩；
select a.sno,sname,sdept,grade
from student a,sc b
where a.sno=b.sno and a.sno in 
(select sno 
from sc 
group by sno 
having count(*)=2)
--3.	查找选修了至少一门和刘晨选修课程一样的学生的学号、姓名及课程号；
select a.sno,sname,cno
from student a,sc b
where a.sno=b.sno and sname<>'刘晨' and cno in 
 (select cno from student a,sc b
  where a.sno=b.sno and sname='刘晨')
--4.查询至少选修了“信息系统”和“数学”这两门课程的学生的基本信息；
select *
from student
where sno in 
(select c.sno  from course a,course b ,sc c,sc d
where a.cno=c.cno and b.cno=d.cno 
and a.cname='信息系统' and b.cname='数学' 
and c.sno=d.sno)

--5.	查询只被一名学生选修的课程的课程号、课程名；
select cno,cname
from course
where cno in (select cno from sc group by cno having count(*)=1)
--6.	检索所学课程包含学生‘刘晨’所学课程的学生学号、姓名；
select sno,sname 
from student a
where sname<>'刘晨' and not exists
    (select * 
	 from  student b,sc c
	 where b.sno=c.sno and sname='刘晨' and not exists
	   (select *
	    from sc d
		where c.cno=d.cno and d.sno=a.sno) )
--7.	使用嵌套查询列出选修了“数学”课程的学生学号和姓名；
select sno,sname 
from student
where sno in (select sno from course a,sc b where a.cno=b.cno and cname='数学')
--8.	使用嵌套查询查询其它系中年龄小于CS系的某个学生的学生姓名、年龄和院系；
select sname,sage,sdept
from student
where sdept<>'CS' and sage<any(select sage from student where sdept='CS')
--9.	使用嵌套查询查询其它系中年龄小于CS系所有学生年龄的学生；
select sname,sage,sdept
from student
where sdept<>'CS' and sage<all(select sage from student where sdept='CS')

--针对company数据库
--1、	在sales表中查找出销售金额最高的订单。
select * 
from sales 
where tot_amt=(select MAX(tot_amt)
                   from sales) 
--2、	在sales表中查找出订单金额大于“E0013业务员在1996/11/10这天所接任一张订单的金额”的所有订单，并显示承接这些订单的业务员和该条订单的金额。
select *
from sales
where tot_amt>any
       (select tot_amt 
        from sales 
        where sale_id='E0013'and order_date='1996/11/10')
--3、	找出公司女业务员所接的订单。
select *
from sales
where sale_id in(select emp_no 
                from employee 
                where sex='女')
--4、	找出目前业绩未超过200000元的员工编号和员工姓名。
select emp_no,emp_name
from employee
where emp_no in (select sale_id 
                 from sales
                 group by sale_id
                 having SUM(tot_amt)<=200000)
--5、	在销售主表sales中查询销售业绩最高的业务员编号及销售业绩。
select sale_id,SUM(tot_amt) 
from sales
group by sale_id
having SUM(tot_amt)=
  (select MAX(sum_amt)
   from(select sale_id,SUM(tot_amt) sum_amt
        from sales
        group by sale_id) a  )
        
 select top 1 with ties sale_id,SUM(tot_amt) sum_amt
        from sales
        group by sale_id 
        order by  sum_amt  desc  
--6、	找出目前业绩超过50000元的员工编号和姓名。
select emp_no,emp_name
from employee
where emp_no in (select sale_id
                 from sales
                 group by sale_id
                 having SUM(tot_amt)>50000)
--7、	查询订购的产品至少包含了订单10003中所订购产品的订单。
select * 
from sales a
where not exists
  (select * 
   from sale_item b
   where order_no='10003' and not exists
      (select *
       from sale_item c
       where b.prod_id=c.prod_id and c.order_no=a.order_no))
--8、查询末承接业务的员工的信息。
select *
from employee
where emp_no not in 
  (select distinct sale_id from sales)
