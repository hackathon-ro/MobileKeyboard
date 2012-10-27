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

//sends the character to the server
-(BOOL)sendsMessageToServer:(NSString *)message
{
    NSData *data = [[NSData alloc] initWithData:[message dataUsingEncoding:NSASCIIStringEncoding]];
    
    int c = [self.outputStream write:[data bytes] maxLength:[data length]];
    
    //check if the message was sent or not
    if( c >= 0 ) return YES;
        else return  NO;
}

//sends the byte 0x02 + a character to the server
-(BOOL)sendsSpecialMessageToServer:(NSString *)message
{
    // send the special byte that specify that is a special character
    unsigned char byte = 0x02;
    
    NSMutableData *data = [[NSMutableData alloc] initWithBytes:&byte length:1];
    
    // check what key was pressed
    if( [message isEqualToString:@"Shift"] )
    {
        [data appendData:[@"S" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"ctrl"] )
    {
        [data appendData:[@"C" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"alt"])
    {
        [data appendData:[@"A" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Up"] )
    {
        [data appendData:[@"U" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Down"] )
    {
        [data appendData:[@"D" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Left"] )
    {
        [data appendData:[@"L" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Right"] )
    {
        [data appendData:[@"R" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"del"] )
    {
        [data appendData:[@"d" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"<"] )
    {
        [data appendData:[@"B" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Space"] )
    {
        [data appendData:[@"s" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"win"] )
    {
        [data appendData:[@"W" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Tab"] )
    {
        [data appendData:[@"T" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Ent"] )
    {
        [data appendData:[@"E" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"Caps"] )
    {
        [data appendData:[@"c" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"esc"])
    {
        [data appendData:[@"e" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F1"] )
    {
        [data appendData:[@"1" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F2"] )
    {
        [data appendData:[@"2" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F3"] )
    {
        [data appendData:[@"3" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F4"] )
    {
        [data appendData:[@"4" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F5"] )
    {
        [data appendData:[@"5" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F6"] )
    {
        [data appendData:[@"6" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F7"] )
    {
        [data appendData:[@"7" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F8"] )
    {
        [data appendData:[@"8" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F9"] )
    {
        [data appendData:[@"9" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F10"] )
    {
        [data appendData:[@"0" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F11"] )
    {
        [data appendData:[@"z" dataUsingEncoding:NSUTF8StringEncoding]];
    } else
    if( [message isEqualToString:@"F12"] )
    {
        [data appendData:[@"q" dataUsingEncoding:NSUTF8StringEncoding]];
    }
    
    
    int c = [self.outputStream write:[data bytes] maxLength:[data length]];
    
    //check if the message was sent or not
    
    if( c > 0 ) return YES;
        else return NO;
}

-(void)stream:(NSStream *)aStream handleEvent:(NSStreamEvent)eventCode
{
    NSLog(@"Stream event %i", eventCode);
}

@end
