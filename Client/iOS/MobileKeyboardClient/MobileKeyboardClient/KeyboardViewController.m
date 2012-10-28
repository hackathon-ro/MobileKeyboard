//
//  ViewController.m
//  MobileKeyboardClient
//
//  Created by Vlad Bogdan on 27/10/12.
//  Copyright (c) 2012 Vlad Bogdan. All rights reserved.
//

#import "InitialViewController.h"
#import "ConnectionManager.h"

@interface InitialViewController ()

@property (strong, nonatomic)  ConnectionManager *connectionManager;

@end

@implementation InitialViewController

- (void)viewDidLoad
{
    [super viewDidLoad];
    
    //set the server details
    self.connectionManager = [[ConnectionManager alloc] init];
    self.connectionManager.serverURL = @"192.168.1.103";
    self.connectionManager.portNumber = 500;
    
    //connect to the server
    [self.connectionManager connectToServer];
}

//method called when a "normal" key is pressed (like "A", "B", "<", etc.)
-(IBAction)keyboardKeyPressed:(UIButton *)sender
{
    [self.connectionManager sendsMessageToServer:sender.titleLabel.text];
}

//method called when a "special" key is pressed (like "CTRL", "ALT", "Enter", etc.)
-(IBAction)keyboardSpecialKeyPressed:(UIButton *)sender
{
    [self.connectionManager sendsSpecialMessageToServer:sender.titleLabel.text];
}

-(NSUInteger)supportedInterfaceOrientations
{
    return UIInterfaceOrientationLandscapeLeft | UIInterfaceOrientationMaskLandscapeRight;
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

@end
