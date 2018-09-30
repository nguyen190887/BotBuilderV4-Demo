provider "aws" {
  region     = "us-west-2"
}

resource "aws_s3_bucket" "BotCodeStorage" {
  bucket = "rita167.bot-storage"
  
}

resource "aws_s3_bucket_object" "BotCodeObject" {
  bucket = "${aws_s3_bucket.BotCodeStorage.id}"
  key = "botv4-demo.zip"
  source = "./botv4-demo.zip"
  etag   = "${md5(file("./botv4-demo.zip"))}"
}

// resource "aws_elastic_beanstalk_application" "BotV4Demo_App" {
//   name        = "BotV4Demo"
//   description = "BotV4Demo"
// }

// resource "aws_elastic_beanstalk_environment" "BotV4Demo_Env" {
//   name                = "BotV4Demo_Env"
//   application         = "${aws_elastic_beanstalk_application.BotV4Demo_App.name}"
//   solution_stack_name = "64bit Amazon Linux 2015.03 v2.0.3 running Go 1.4"
// }
