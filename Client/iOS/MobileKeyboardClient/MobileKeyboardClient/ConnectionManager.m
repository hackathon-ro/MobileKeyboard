//
//  ConnectionManager.m
//  MobileKeyboardClient
//
//  Created by Vlad Bogdan on 27/10/12.
//  Copyright (c) 2012 Vlad Bogdan. All rights reserved.
//

#import "ConnectionManager.h"

//private variables
@interface ConnectionManager ()

@property (strong, nonatomic) NSInputStream *inputStream;
@property (strong, nonatomic) NSOutputStream *outputStream;

@end

@implementation ConnectionManager


//method that connects to the server
-(void)connectToServer
{
    CFReadStreamRef readStreamRef;
    CFWriteStreamRef writeStreamRef;
    
    CFStreamCreatePairWithSocketToHost(NULL, (__bridge CFStringRef)self.serverURL, self.portNumber , &readStreamRef, &writeStreamRef);

    self.inputStream = (__bridge NSInputStream *) readStreamRef;
    self.outputStream = (__bridge NSOutputStream *) writeStreamRef;
    
    [self.inputStream setDelegate:self];
    [self.inputStream setDelegate:self];
    
    [self.inputStream scheduleInRunLoop:[NSRunLoop currentRunLoop] forMode:NSDefaultRunLoopMode];
    [self.outputStream scheduleInRunLoop:[NSRunLoop currentRunLoop] forMode:NSDefaultRunLoopMode];
    
    [self.inputStream open];
    [self.outputStream open];
}

-(BOOL)sendsMessageToServer:(NSString *)message
{
    NSData *data = [[NSData alloc] initWithData:[message dataUsingEncoding:NSASCIIStringEncoding]];
    
    int c = [self.outputStream write:[data bytes] maxLength:[data length]];
    
    NSLog(@"metoda apelata!");
    
    //check if the message was sent or not
    if( c >= 0 ) return YES;
        else return  NO;
}

-(void)stream:(NSStream *)aStream handleEvent:(NSStreamEvent)eventCode
{
    NSLog(@"Stream event %i", eventCode);
}

@end
