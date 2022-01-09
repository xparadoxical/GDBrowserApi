using System.Text.Json;
using System.Text.Json.Serialization;

namespace GDBrowserApi.Levels
{
	public sealed class DifficultyConverter : JsonConverter<Difficulty>
	{//TODO
		public override Difficulty Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => throw new NotImplementedException();
		public override void Write(Utf8JsonWriter writer, Difficulty value, JsonSerializerOptions options) => throw new NotImplementedException();
	}
}
