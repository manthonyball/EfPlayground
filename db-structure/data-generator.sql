IF object_id(N'fn_GetRandomInt', N'dbo') IS NOT NULL
    select 1;
    DROP FUNCTION dbo.fn_GetRandomInt
GO
CREATE function dbo.fn_GetRandomInt(@fn_isActive_rand float)
returns int
AS
BEGIN 
   RETURN IIF(@fn_isActive_rand > 0.2 And @fn_isActive_rand < 0.4 , 2, 
		                      IIF(@fn_isActive_rand > 0.4 And @fn_isActive_rand < 0.5 , 3,
								IIF(@fn_isActive_rand > 0.5 And @fn_isActive_rand < 0.7 , 4,
								  IIF(@fn_isActive_rand > 0.7 And @fn_isActive_rand < 0.9 , 0,
								    5))));
END 
GO

--- configuration 
declare @inser_size int = 100;
declare @isInsertAgnt bit = 0;
declare @isMorgageAgnt bit = 1;

--- script variables 
declare @counter int = 10;
declare @isActive int = 0;
declare @isActive_rand float;

declare @total_row_d int;
declare @total_row_h int;
declare @agnt_rand_d int;
declare @agnt_rand_h int;
declare @hAgntCode uniqueidentifier;
declare @dAgntCode uniqueidentifier;

if(@isInsertAgnt = 1) 
BEGIN
  set @counter = @inser_size;
  WHILE(@counter > 0)
  BEGIN 
  	 set @isActive = dbo.fn_GetRandomInt(rand());
  	
      insert into  [dbo].[directAgent] ([Active]) values (@isActive);
      insert into  [dbo].[hubAgent] ([Active]) values (@isActive);
  	set @counter =  @counter-1; 
  END;
END;


if(@isMorgageAgnt = 1) 
BEGIN
  set @counter = @inser_size;
  
  select @total_row_d = count(1) from [dbo].[directAgent] ;
  select @total_row_h = count(1) from [dbo].[hubAgent] ;
   
  set @agnt_rand_d = rand() * @total_row_d;
  set @agnt_rand_h = rand() * @total_row_h;
  
  WHILE(@counter > 0)
  BEGIN
            set @agnt_rand_d = rand()* @inser_size;
  	      set @isActive = dbo.fn_GetRandomInt(rand());
  		  select @dAgntCode = code
  		  from 
  		  (
              SELECT ROW_NUMBER() OVER(ORDER BY code DESC) AS RowNum,   
                     code  
              FROM [dbo].[directAgent] 
  		  ) d
  		  where RowNum = @agnt_rand_d ; 
  
  		  select @hAgntCode = code
  		  from 
  		  (
              SELECT ROW_NUMBER() OVER(ORDER BY code DESC) AS RowNum,   
                     code  
              FROM [dbo].[hubAgent] 
  		  ) d
  		  where RowNum = @agnt_rand_h ; 
     
            INSERT INTO [dbo].[MortgageAgent]
                   ([HubAgent]
                   ,[DirectAgent]
                   ,[Active]  )
             VALUES
             (@hAgntCode
             ,null
             ,@isActive),
             (null
             ,@dAgntCode
             ,@isActive);
  	set @counter =  @counter-1; 
  END;
END;