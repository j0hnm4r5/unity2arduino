#include <SerialCommand.h> // import library to help subscribe to Serial events

SerialCommand sCmd; // define the library's use

#define BAUD 9600 // define a global variable for the serial Baud rate

const int ledPin = 6;    // define the digital pin to control the LED
const int sensorPin = 0; // define the analog pin to read the photocell value

void setup() // run once when arduino is reset
{
  Serial.begin(BAUD); // initialize the serial connection with the baud rate

  pinMode(ledPin, OUTPUT); // set the LED's pin to output power instead of read/sense it

  // add callbacks for potential commands over serial
  sCmd.addCommand("BOOM", blink);
  sCmd.addCommand("PING", ping);
  // sCmd.setDefaultHandler(unrecognized);

  Serial.println("Arduino Ready!"); // send this over serial
}

void loop() // runs continuously
{
  sCmd.readSerial(); // read the commands coming in from Unity
}

void blink() // blink the LED
{
  digitalWrite(ledPin, HIGH); // turn the LED on (HIGH is the voltage level)
  delay(50);                  // wait for milliseconds
  digitalWrite(ledPin, LOW);  // turn the LED off by making the voltage LOW
}

void ping() // respond to a ping request from Unity
{
  Serial.print("PONG: ");
  Serial.println(analogRead(sensorPin)); // read the photocell value and send it over serial
}

void unrecognized(const char *command) // default handler: called when no command matches
{
  Serial.println("What?");
}
