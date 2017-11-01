use master;
go

-- 建立空的MyPetShop数据库
-- 根据实际环境更改数据库文件和日志文件的存放路径

create database MyPetShop on
(
  name = MyPetShop,
  filename = 'E:\studiospace\Experiments\Experiment\Ex7LinqSqlSite\App_Data\MyPetShop.mdf',
  size = 5MB,
  maxsize = 50MB,
  filegrowth = 1MB
)
log on
(
  name = MyPetShop_log,
  filename = 'E:\studiospace\Experiments\Experiment\Ex7LinqSqlSite\App_Data\MyPetShop_log.ldf',
  size = 3MB,
  maxsize = 25MB,
  filegrowth = 1MB
)
collate Chinese_PRC_CI_AS; -- 支持中文编码
go

use MyPetShop

-- 分别建立Category、Supplier、Product、Order、OrderItem等数据表的结构

-- Category表
create table [Category]
(
  [CategoryId] int identity primary key,
  [Name] varchar(80) null,
  [Descn] varchar(255) null
)

-- Supplier表
create table [Supplier]
(
  [SuppId] int identity primary key,
  [Name] varchar(80) null,
  [Addr1] varchar(80) null,
  [Addr2] varchar(80) null,
  [City] varchar(80) null,
  [State] varchar(80) null,
  [Zip] varchar(6) null,
  [Phone] varchar(40) null
)

-- Product表
create table [Product]
(
  [ProductId] int identity primary key,
  [CategoryId] int not null references [Category]([CategoryId]),
  [ListPrice] decimal(10, 2) null,
  [UnitCost] decimal(10, 2) null,
  [SuppId] int null references [Supplier]([SuppId]),
  [Name] varchar(80) null,
  [Descn] varchar(255) null,
  [Image] varchar(80) null,
  [Qty] int not null
)

-- Order表
create table [Order]
(
  [OrderId] int identity primary key,
  [UserName] varchar(80) not null,
  [OrderDate] datetime not null,
  [Addr1] varchar(80) null,
  [Addr2] varchar(80) null,
  [City] varchar(80) null,
  [State] varchar(80) null,
  [Zip] varchar(6) null,
  [Phone] varchar(40) null,
  [Status] varchar(10) null
)

-- OrderItem表
create table [OrderItem]
(
  [ItemId] int identity primary key,
  [OrderId] int not null references [Order]([OrderId]),
  [ProName] varchar(80),
  [ListPrice] decimal(10, 2) null,
  [Qty] int not null,
  [TotalPrice] decimal(10, 2) null
)

go

-- 在Category表中插入数据
insert into [Category] values('Fish', 'Fish')
insert into [Category] values('Backyard', 'Backyard')
insert into [Category] values('Birds', 'Birds')
insert into [Category] values('Bugs', 'Bugs')
insert into [Category] values('Endangered', 'Endangered')

-- 在Supplier表中插入数据
insert into [Supplier] values('XYZ Pets', '600 Avon Way', '', 'Los Angeles', 'CA', '94024', '212-947-0797') -- ''中无空格
insert into [Supplier] values('ABC Pets', '700 Abalone Way', '', 'San Francisco', 'CA', '94024', '415-947-0797') -- ''中无空格

-- 在Product表中插入数据
insert into [Product] values(1, 12.1, 11.4, 1, 'Meno', 'Meno', '~/Prod_Images/Fish/meno.gif', 100)
insert into [Product] values(1, 28.5, 25.5, 1, 'Eucalyptus', 'Eucalyptus', '~/Prod_Images/Fish/eucalyptus.gif', 100)
insert into [Product] values(2, 23.4, 11.4, 1, 'Ant', 'Ant', '~/Prod_Images/Bugs/ant.gif', 100)
insert into [Product] values(2, 24.7, 22.2, 1, 'Butterfly', 'Butterfly', '~/Prod_Images/Bugs/butterfly.gif', 100)
insert into [Product] values(3, 38.5, 37.2, 1, 'Cat', 'Cat', '~/Prod_Images/Backyard/cat.gif', 100)
insert into [Product] values(3, 40.4, 38.7, 1, 'Zebra', 'Zebra', '~/Prod_Images/Backyard/zebra.gif', 100)
insert into [Product] values(4, 45.5, 44.2, 1, 'Domestic', 'Domestic', '~/Prod_Images/Birds/domestic.gif', 100)
insert into [Product] values(4, 25.2, 23.5, 1, 'Flowerloving', 'Flowerloving', '~/Prod_Images/Birds/meno.gif', 100)
insert into [Product] values(5, 47.7, 45.5, 1, 'Panda', 'Panda', '~/Prod_Images/Endangered/meno.gif', 100)
insert into [Product] values(5, 35.5, 33.5, 1, 'Pointy', 'Pointy', '~/Prod_Images/Endangered/meno.gif', 100)

go