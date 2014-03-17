Entity Framework PRIME
===

This is a fork of Microsoft's Entity Framework repo: 
http://entityframework.codeplex.com/

### Changes made by Helm Operations

Add DateTimeOffset support for SQL CE

SQL Compact Edition does not have a DATETIMEOFFSET field. Accepted
practise is to use NVARCHAR instead, however, entity framework does not
know how to convert between .NET's DateTimeOffset and SQL's NVARCHAR
type. This change allows for that conversion, and does so in such a way
that queries can compare dates by simply comparing strings even if the
date strings are in different time zones with the following technique:

1. The date "2014-03-17T19:52:09+01:00" is stored in the database as
"2014-03-17T18:52:09+01:00". Normally DateTimeOffset strings are
stored as "LOCAL-TIME+OFFSET" but instead we store "UTC-TIME+OFFSET".
2. When a literal DateTimeOffset value is being converted to a SQL
string for comparison in a WHERE clause it is converted to a UTC
string.
3. When a DateTimeOffset string is being read from the database it is
parsed into a DateTimeOffset object and the offset is reversed so
that the actual DateTime component is in local time (as it should be).

The only drawbacks are that there may be a loss in performance when
filtering on dates, and it is a little confusing when you read data
directly from the database (like when troubleshooting) because storing
date strings as "UTC-TIME+OFFSET" is not normal.

### License

This project retains Entity Framework's Apache 2.0 license:

http://www.apache.org/licenses/LICENSE-2.0.html

As stated in the license, Helm Operations provides the software as is
with no guarantees.
