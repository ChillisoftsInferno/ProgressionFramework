using DialogueSystem.Domain;
using ProgressionFramework_Dante_Level1.Json;

var jsonSerializationOptionsPath =
    Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/JsonSerializationOptions.json");
var playerSaveFilePath =
    Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/PlayerSaveData.json");
var filePathToSaveTo =
    Path.Combine(AppContext.BaseDirectory, "../../../../GlobalHelpers/Resources/JSON/NewPlayerSaveData.json");

var jsonWithOptions = JsonManager.GetInstance().WithJsonOptions(jsonSerializationOptionsPath);

var deserializer = new Deserialization(jsonWithOptions.GetJsonOptions());

deserializer.SetDeserializationFilePath(playerSaveFilePath);
var results = deserializer.Deserialize<List<PlayerSave>>();

var serializer = new Serialization(jsonWithOptions.GetJsonOptions());
serializer.SaveToJson(results, filePathToSaveTo);