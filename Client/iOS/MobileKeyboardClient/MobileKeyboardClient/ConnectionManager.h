//
//  ConnectionManager.h
//  MobileKeyboardClient
//
//  Created by Vlad Bogdan on 27/10/12.
//  Copyright (c) 2012 Vlad Bogdan. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "CoreFoundation/CoreFoundation.h"

@interface ConnectionManager : NSObject
<NSStreamDelegate>

-(void)connectToServer;
-(BOOL)sendsMessageToServer:(NSString *)message;

@property int portNumber;
@property (strong, nonatomic) NSString *serverURL;

@end
