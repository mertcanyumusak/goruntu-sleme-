void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);

pinMode(2,OUTPUT);
pinMode(3,OUTPUT);
pinMode(4,OUTPUT);
pinMode(5,OUTPUT);
pinMode(6,OUTPUT);
pinMode(7,OUTPUT);
pinMode(8,OUTPUT);
pinMode(9,OUTPUT);
pinMode(10,OUTPUT);

}

void loop(){

  
char c = Serial.read();

if (c=='1')
{
        digitalWrite(2,HIGH);
        digitalWrite(3,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
}
     else  if (c=='2')
{
        digitalWrite(3,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
}
  else  if (c=='3')
{
        digitalWrite(4,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(3,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
}
  else  if (c=='4')
{
        digitalWrite(5,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(3,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
}
  else  if (c=='5')
{
        digitalWrite(6,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(3,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
}
  else  if (c=='6')
{
        digitalWrite(7,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(3,LOW);
        digitalWrite(6,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
}
  else  if (c=='7')
{
        digitalWrite(8,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(3,LOW);
        digitalWrite(9,LOW);
        digitalWrite(10,LOW);
}
  else  if (c=='8')
{
        digitalWrite(9,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(3,LOW);
        digitalWrite(10,LOW);
}
  else  if (c=='9')
{
        digitalWrite(10,HIGH);
        digitalWrite(2,LOW);
        digitalWrite(4,LOW);
        digitalWrite(5,LOW);
        digitalWrite(6,LOW);
        digitalWrite(7,LOW);
        digitalWrite(8,LOW);
        digitalWrite(9,LOW);
        digitalWrite(3,LOW);
}
}
