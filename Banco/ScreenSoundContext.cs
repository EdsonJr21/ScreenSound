using Microsoft.EntityFrameworkCore;
using ScreenSound.Modelos;
using DotNetEnv;

namespace ScreenSound.Banco
{
    internal class ScreenSoundContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Musica> Musicas { get; set; }

        private string _connectionString;

        public ScreenSoundContext()
        {
            Env.Load();

            _connectionString = Environment.GetEnvironmentVariable("SCREEN_SOUND_CONNECTION_STRING");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new InvalidOperationException("A string de conexão não foi definida em uma variável de ambiente.");
            }

            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
