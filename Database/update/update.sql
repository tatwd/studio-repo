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

-- TODO


-- --------
-- 针对`coampany`
-- --------

-- --------
-- END!
-- --------