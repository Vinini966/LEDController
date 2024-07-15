#include <FastLED.h>
#include <ArduinoJson.h>
#define ARDUINOJSON_DEFAULT_NESTING_LIMIT 20
#define NUM_LEDS 60
#define DI_PIN 4
#define PATTERN "P"
#define LIST "List"
#define COLOR "C"
#define LEDAMOUNT "N"

CRGB leds[NUM_LEDS];
void setup() { 

  Serial.begin(9600);
  SetupLEDs();

  fill_solid( &(leds[0]), NUM_LEDS , CRGB(0, 0, 0) );
  FastLED.show();
}
void loop() {
  if (Serial.available() > 0) {
    // Read JSON string from serial
    String jsonString = Serial.readStringUntil('\n');

    // Deserialize JSON string
    JsonDocument doc;
    DeserializationError error = deserializeJson(doc, jsonString);
    serializeJson(doc, Serial);
    if (error) {
      Serial.print("deserializeJson() returned ");
      Serial.println(error.c_str());
      return;
    } 

    // Extract data from JSON
    JsonArray ledArray = doc[LIST];
    
    int startLED = 0;
    for(int i = 0; i < ledArray.size(); i++){
      int ledAmount = ledArray[i][LEDAMOUNT];
      int R = ledArray[i][COLOR]["R"],
          G = ledArray[i][COLOR]["G"],
          B = ledArray[i][COLOR]["B"];

      if(ledAmount > 0){
        fill_solid( &(leds[startLED]), ledAmount , CRGB(R, G, B) );
      }
      
      startLED = startLED + ledAmount;
    }
    
    FastLED.show(); 
  }
	
}

void SetupLEDs(){
  FastLED.addLeds<NEOPIXEL, DI_PIN>(leds, NUM_LEDS); 
  
}