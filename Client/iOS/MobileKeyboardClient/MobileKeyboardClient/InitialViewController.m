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
    
    self.connectionManager = [[ConnectionManager alloc] init];
    self.connectionManager.serverURL = @"192.168.1.103";
    self.connectionManager.portNumber = 11000;
    [self.connectionManager connectToServer];
}

-(IBAction)keyboardKeyPressed:(UIButton *)sender
{
    [self.connectionManager sendsMessageToServer:sender.titleLabel.text];
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
