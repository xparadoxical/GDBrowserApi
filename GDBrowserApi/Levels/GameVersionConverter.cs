using System.Text.Json;
using System.Text.Json.Serialization;

namespace GDBrowserApi.Levels
{
	public sealed class GameVersionConverter : JsonConverter<GameVersion>
	{//TODO
		public override GameVersion Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
		public override void Write(Utf8JsonWriter writer, GameVersion value, JsonSerializerOptions options) => throw new NotImplementedException();
	}
}
