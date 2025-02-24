﻿using FS.EAuctions.Application.Bids.Create;

namespace FS.EAuctions.Application.BuyerAuctions.Create;

public record BuyerAuctionForCreationDto(
    string Name,
    DateTimeOffset StartAuctionDateTime,
    DateTimeOffset EndAuctionDateTime,
    string Description, 
    Guid CreatedBy);