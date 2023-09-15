-- This section contains a function to randomly assign restaurants and hotels to most of the countries in the countries table (avoiding duplicates).


DECLARE @cont INT
SET @cont = 0

WHILE @cont < 220
BEGIN
    DECLARE @RandomCountryId INT
    DECLARE @RandomRestaurantId INT
    DECLARE @RandomHotelId INT


    set @RandomCountryId = FLOOR(RAND() * (216 - 2 + 1) + 2)   
    set @RandomRestaurantId = FLOOR(RAND() * (10 - 2 + 1) + 2)   
    set @RandomHotelId = FLOOR(RAND() * (10 - 2 + 1) + 2)        


    IF NOT EXISTS (
        select 1
        from CountrySites
        where CountryId = @RandomCountryId
        AND RestaurantId = @RandomRestaurantId
        AND HotelId = @RandomHotelId
    )
    BEGIN

        insert into CountrySites (CountryId, RestaurantId, HotelId)
        values (@RandomCountryId, @RandomRestaurantId, @RandomHotelId)
        set @cont = @cont + 1
    END
END