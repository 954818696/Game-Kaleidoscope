// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "Pickup.h"
#include "BatteryPickup.generated.h"

/**
 * 
 */
UCLASS()
class ABatteryPickup : public APickup
{
	GENERATED_BODY()
	
public:
	ABatteryPickup();
	
	void WasCollected_Implementation() override;

	float GetPower();

protected:
	UPROPERTY(EditAnywhere, BlueprintReadWrite, Category = Power, Meta = (BlueprintProtected =  "true"))
	float BatteryPower;
};
