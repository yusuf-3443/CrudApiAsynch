﻿using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string _connectionString =
        $@"Server=localhost;port=5432;database=homtask2;User Id=postgres;password=12345;";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }

}