-- CREATE the existing trigger
CREATE TRIGGER trg_PS_DOC_LIN_Replenishment
ON PS_DOC_LIN
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert records into USER_SUGGESTED_REPLENISHMENT for inserted records
    INSERT INTO [dbo].[USER_SUGGESTED_REPLENISHMENT] (LocationID, ItemID, SuggestedQuantity, DateCreated)
    SELECT im.LOC_ID , i.ITEM_NO , (im.MIN_QTY - i.QTY_SOLD), GETDATE() AS DateCreated
    FROM inserted i
    JOIN IM_INV im ON i.STK_LOC_ID = im.LOC_ID AND i.ITEM_NO = im.ITEM_NO
    WHERE im.MIN_QTY > i.QTY_SOLD;
END;
